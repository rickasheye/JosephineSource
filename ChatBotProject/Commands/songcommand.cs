using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.VoiceNext;
using DSharpPlus.VoiceNext.EventArgs;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBotProject.Commands
{
    public class songcommand : CommandModule
    {
        public List<string> getSongQueue(DiscordGuild guild)
        {
            List<string> gotQueue = new List<string>();
            foreach(guildData data in JosephineBot.data)
            {
                if(data.guildId == guild.Id)
                {
                    gotQueue.AddRange(data.queue);
                }
            }
            return gotQueue;
        }

        public DiscordChannel getTheNearestVoiceChannel(DiscordGuild guild)
        {
            DiscordChannel voiceChannel = null;
            if (voiceChannel == null)
            {
                foreach (DiscordChannel channels in guild.Channels.Values)
                {
                    if (channels.Type == DSharpPlus.ChannelType.Voice)
                    {
                        voiceChannel = channels;
                    }
                } 
            }
            return voiceChannel;
        }

        SpotifyWebAPI api;

        [Command("song"),Description("Plays a song in the specified voice channel"), Hidden]
        public override async Task OperateCommand(CommandContext ctx, params string[] args)
        {
            await base.OperateCommand(ctx, args);
            string subCommand = args[0];
            guildData data = Utils.returnGuildData(ctx.Guild.Id);

            switch (subCommand.ToLower())
            {
                case "play":
                    //Play the tunes!
                    await VoiceJoin(ctx);
                    //We need to download the spotify song or whatever
                    if(args[1] != null)
                    {
                        //Start to play the song
                        if(args[1].Contains("youtube") || args[1].Contains("youtu.be"))
                        {

                        }
                        else if(args[1].Contains("spotify"))
                        {
                            //Initialise the spotify bot if has not done yet!
                            if(api == null)
                            {
                                CredentialsAuth auth = new CredentialsAuth("7c09a36e2ef84c2abc068c8979103d17", "d21bc05a3f604089b176e3b3e5975e0b");
                                Token token = await auth.GetToken();
                                api = new SpotifyWebAPI
                                {
                                    AccessToken = token.AccessToken,
                                    TokenType = token.TokenType
                                };
                            }

                            string uriCode = null;
                            Uri uri = new UriBuilder(args[1]).Uri;

                            if (args[1] != null)
                            {
                                //Get the spotify track from url or the uri code
                                uriCode = uri.Segments[2];
                            }

                            if (uriCode != null)
                            {
                                if (uri.Segments[1] == "track")
                                {
                                    FullTrack track = await api.GetTrackAsync(uriCode);
                                    if (track.Artists != null)
                                    {
                                        List<string> artists = new List<string>();
                                        foreach (SimpleArtist artist in track.Artists)
                                        {
                                            artists.Add(artist.Name);
                                        }
                                        string connectArtist = string.Join(",", artists.ToArray());
                                        await ctx.RespondAsync("Playing: " + track.Name + " By: " + connectArtist);
                                    }
                                    if (track.HasError())
                                    {
                                        await ctx.RespondAsync("The track when playing had an issue!");
                                    } 
                                }else if(uri.Segments[1] == "playlist")
                                {
                                    //Playlist
                                    FullPlaylist list = await api.GetPlaylistAsync(uriCode);
                                    await ctx.RespondAsync("Playing: " + list.Name);
                                    if (list.HasError())
                                    {
                                        await ctx.RespondAsync("The playlist had and issue");
                                    }
                                }
                            }
                            else
                            {
                                await ctx.RespondAsync("Invalid url or uri code");
                            }
                        }
                    }
                    else
                    {
                        await ctx.RespondAsync("No song link was defined!");
                    }
                    break;
                case "stop":
                    //Stop the tunes!
                    
                    break;
                case "leave":
                case "fuckoff":
                    //Leave the channel forcefully!
                    await VoiceLeave(ctx);
                    break;
                case "autoleave":
                    //Set if the bot should automatically leave the voice channel when no one is in the voice channel
                    if(data.autoSongLeave == false)
                    {
                        data.autoSongLeave = true;
                        await ctx.RespondAsync("This bot will leave the party when everyone else has finished!");
                    }else if(data.autoSongLeave == true)
                    {
                        data.autoSongLeave = false;
                        await ctx.RespondAsync("This bot will keep on partying!");
                    }
                    break;
                case "loop":
                    //loop the song that is currently playing
                    if(data.loopSong == false)
                    {
                        data.loopSong = true;
                        await ctx.RespondAsync("Looping Song !");
                    }else if(data.loopSong == true)
                    {
                        data.loopSong = false;
                        await ctx.RespondAsync("Not Looping Song!");
                    }
                    break;
                default:
                case "help":
                    //Show the help on it.
                    Dictionary<string, string> argumentsHelp = new System.Collections.Generic.Dictionary<string, string>();
                    argumentsHelp.Add(";;song play", "specify a song right after play with a space then this bot will play or specify a link (overrides queue)");
                    argumentsHelp.Add(";;song stop", "stop whatever is playing");
                    argumentsHelp.Add(";;song leave", "forces the bot to leave the current voice channel");
                    argumentsHelp.Add(";;song autoleave", "turns on auto leave the bot will leave the channel when no one is present");
                    argumentsHelp.Add(";;song loop", "loops the current song and disables queue");
                    DiscordEmbed embedHelp = JosephineEmbedBuilder.CreateEmbedMessage(ctx, "Sub-Commands", "for ';;announce set'", null, JosephineBot.defaultColor, argumentsHelp, false);
                    await ctx.RespondAsync("Go to http://discord.rickasheye.xyz/ for all sub-commands", false, embedHelp);
                    break;
            }
        }

        private CancellationTokenSource AudioLoopCancelTokenSource { get; set; }
        private CancellationToken AudioLoopCancelToken => this.AudioLoopCancelTokenSource.Token;
        private Task AudioLoopTask { get; set; }

        private ConcurrentDictionary<uint, ulong> _ssrcMap;
        private ConcurrentDictionary<uint, FileStream> _ssrcFilemap;
        private async Task OnVoiceReceived(VoiceReceiveEventArgs e)
        {
            if (!this._ssrcFilemap.ContainsKey(e.SSRC))
                this._ssrcFilemap[e.SSRC] = File.Create($"{e.SSRC} ({e.AudioFormat.ChannelCount}).pcm");
            var fs = this._ssrcFilemap[e.SSRC];

            // e.Client.DebugLogger.LogMessage(LogLevel.Debug, "VNEXT RX", $"{e.User?.Username ?? "Unknown user"} sent voice data. {e.AudioFormat.ChannelCount}", DateTime.Now);
            var buff = e.PcmData.ToArray();
            await fs.WriteAsync(buff, 0, buff.Length).ConfigureAwait(false);
            // await fs.FlushAsync().ConfigureAwait(false);
        }

        private Task OnUserSpeaking(UserSpeakingEventArgs e)
        {
            if (this._ssrcMap.ContainsKey(e.SSRC))
                return Task.CompletedTask;

            if (e.User == null)
                return Task.CompletedTask;

            this._ssrcMap[e.SSRC] = e.User.Id;
            return Task.CompletedTask;
        }

        private Task OnUserJoined(VoiceUserJoinEventArgs e)
        {
            this._ssrcMap.TryAdd(e.SSRC, e.User.Id);
            return Task.CompletedTask;
        }

        private Task OnUserLeft(VoiceUserLeaveEventArgs e)
        {
            if (this._ssrcFilemap.TryRemove(e.SSRC, out var pcmFs))
                pcmFs.Dispose();
            this._ssrcMap.TryRemove(e.SSRC, out _);
            return Task.CompletedTask;
        }

        public async Task VolumeAsync(CommandContext ctx, double vol = 1.0)
        {
            if (vol < 0 || vol > 2.5)
                throw new ArgumentOutOfRangeException(nameof(vol), "Volume needs to be between 0 and 250% inclusive.");

            var voice = ctx.Client.GetVoiceNext();
            if (voice == null)
            {
                await ctx.Message.RespondAsync("Voice is not activated").ConfigureAwait(false);
                return;
            }

            var vnc = voice.GetConnection(ctx.Guild);
            if (vnc == null)
            {
                await ctx.Message.RespondAsync("Voice is not connected in this guild").ConfigureAwait(false);
                return;
            }

            var transmitStream = vnc.GetTransmitStream();
            transmitStream.VolumeModifier = vol;

            await ctx.RespondAsync($"Volume set to {(vol * 100).ToString("0.00")}%").ConfigureAwait(false);
        }

        public async Task VoiceJoin(CommandContext ctx)
        {
            var chn = ctx.Member?.VoiceState?.Channel;
            if (chn == null)
            {
                await ctx.Message.RespondAsync("Your voice channel was not found or you are not connected").ConfigureAwait(false);
                return;
            }

            var vnc = await chn.ConnectAsync().ConfigureAwait(false);
            await ctx.Message.RespondAsync($"Tryina join `{chn.Name}` ({chn.Id})").ConfigureAwait(false);

            if (ctx.Client.GetVoiceNext().IsIncomingEnabled)
            {
                this._ssrcMap = new ConcurrentDictionary<uint, ulong>();
                this._ssrcFilemap = new ConcurrentDictionary<uint, FileStream>();
                vnc.VoiceReceived += this.OnVoiceReceived;
                vnc.UserSpeaking += this.OnUserSpeaking;
                vnc.UserJoined += this.OnUserJoined;
                vnc.UserLeft += this.OnUserLeft;
            }
        }

        public async Task VoiceLeave(CommandContext ctx)
        {
            var voice = ctx.Client.GetVoiceNext();
            if (voice == null)
            {
                await ctx.Message.RespondAsync("Voice is not activated").ConfigureAwait(false);
                return;
            }

            var vnc = voice.GetConnection(ctx.Guild);
            if (vnc == null)
            {
                await ctx.Message.RespondAsync("Voice is not connected in this guild").ConfigureAwait(false);
                return;
            }

            if (voice.IsIncomingEnabled)
            {
                vnc.UserSpeaking -= this.OnUserSpeaking;
                vnc.VoiceReceived -= this.OnVoiceReceived;

                foreach (var kvp in this._ssrcFilemap)
                    kvp.Value.Dispose();

                using (var fs = File.Create("index.txt"))
                using (var sw = new StreamWriter(fs, new UTF8Encoding(false)))
                    foreach (var kvp in this._ssrcMap)
                        await sw.WriteLineAsync(string.Format("{0} = {1}", kvp.Key, kvp.Value)).ConfigureAwait(false);
            }

            vnc.Disconnect();
            await ctx.Message.RespondAsync("Disconnected").ConfigureAwait(false);
        }

        public async Task VoicePlay(CommandContext ctx, params string[] filename)
        {
            var voice = ctx.Client.GetVoiceNext();
            if (voice == null)
            {
                await ctx.Message.RespondAsync("Voice is not activated").ConfigureAwait(false);
                return;
            }

            var vnc = voice.GetConnection(ctx.Guild);
            if (vnc == null)
            {
                await ctx.Message.RespondAsync("Voice is not connected in this guild").ConfigureAwait(false);
                return;
            }

            var snd = string.Join(" ", filename);
            if (string.IsNullOrWhiteSpace(snd) || !File.Exists(snd))
            {
                await ctx.Message.RespondAsync("Invalid file specified").ConfigureAwait(false);
                return;
            }

            while (vnc.IsPlaying)
            {
                await ctx.Message.RespondAsync("This connection is playing audio, waiting for end.").ConfigureAwait(false);
                await vnc.WaitForPlaybackFinishAsync().ConfigureAwait(false);
            }

            Exception exc = null;
            await ctx.Message.RespondAsync($"Playing `{snd}`").ConfigureAwait(false);
            try
            {
                // borrowed from
                // https://github.com/RogueException/Discord.Net/blob/5ade1e387bb8ea808a9d858328e2d3db23fe0663/docs/guides/voice/samples/audio_create_ffmpeg.cs

                var ffmpeg_inf = new ProcessStartInfo
                {
                    FileName = "ffmpeg",
                    Arguments = $"-i \"{snd}\" -ac 2 -f s16le -ar 48000 pipe:1",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                var ffmpeg = Process.Start(ffmpeg_inf);
                var ffout = ffmpeg.StandardOutput.BaseStream;

                var transmitStream = vnc.GetTransmitStream();
                await ffout.CopyToAsync(transmitStream).ConfigureAwait(false);
                await transmitStream.FlushAsync().ConfigureAwait(false);

                await vnc.WaitForPlaybackFinishAsync().ConfigureAwait(false);
            }
            catch (Exception ex) { exc = ex; }

            if (exc != null)
                throw exc;
        }

        public async Task VoicePlayLoop(CommandContext ctx, params string[] filename)
        {
            var voice = ctx.Client.GetVoiceNext();
            if (voice == null)
            {
                await ctx.Message.RespondAsync("Voice is not activated").ConfigureAwait(false);
                return;
            }

            var vnc = voice.GetConnection(ctx.Guild);
            if (vnc == null)
            {
                await ctx.Message.RespondAsync("Voice is not connected in this guild").ConfigureAwait(false);
                return;
            }

            if (this.AudioLoopTask != null && !this.AudioLoopCancelToken.IsCancellationRequested)
            {
                await ctx.Message.RespondAsync("Audio loop is already playing").ConfigureAwait(false);
                return;
            }

            var snd = string.Join(" ", filename);
            if (string.IsNullOrWhiteSpace(snd) || !File.Exists(snd))
            {
                await ctx.Message.RespondAsync("Invalid file specified").ConfigureAwait(false);
                return;
            }

            await ctx.Message.RespondAsync($"Playing `{snd}` in a loop").ConfigureAwait(false);
            this.AudioLoopCancelTokenSource = new CancellationTokenSource();
            this.AudioLoopTask = Task.Run(async () =>
            {
                var chn = ctx.Channel;
                var token = this.AudioLoopCancelToken;
                try
                {
                    // borrowed from
                    // https://github.com/RogueException/Discord.Net/blob/5ade1e387bb8ea808a9d858328e2d3db23fe0663/docs/guides/voice/samples/audio_create_ffmpeg.cs

                    var ffmpeg_inf = new ProcessStartInfo
                    {
                        FileName = "ffmpeg",
                        Arguments = $"-i \"{snd}\" -ac 2 -f s16le -ar 48000 pipe:1",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };
                    var ffmpeg = Process.Start(ffmpeg_inf);
                    var ffout = ffmpeg.StandardOutput.BaseStream;

                    var transmitStream = vnc.GetTransmitStream();
                    await ffout.CopyToAsync(transmitStream).ConfigureAwait(false);
                    await transmitStream.FlushAsync().ConfigureAwait(false);

                    await vnc.WaitForPlaybackFinishAsync().ConfigureAwait(false);
                }
                catch (OperationCanceledException) { }
                catch (Exception ex) { await chn.SendMessageAsync($"Audio loop crashed: {ex.GetType()}: {ex.Message}").ConfigureAwait(false); }
            }, this.AudioLoopCancelToken);
        }

        public async Task VoicePlayLoopStop(CommandContext ctx)
        {
            var voice = ctx.Client.GetVoiceNext();
            if (voice == null)
            {
                await ctx.Message.RespondAsync("Voice is not activated").ConfigureAwait(false);
                return;
            }

            var vnc = voice.GetConnection(ctx.Guild);
            if (vnc == null)
            {
                await ctx.Message.RespondAsync("Voice is not connected in this guild").ConfigureAwait(false);
                return;
            }

            if (this.AudioLoopTask == null || this.AudioLoopCancelToken.IsCancellationRequested)
            {
                await ctx.Message.RespondAsync("Audio loop is already paused").ConfigureAwait(false);
                return;
            }

            this.AudioLoopCancelTokenSource.Cancel();
            await this.AudioLoopTask.ConfigureAwait(false);
            this.AudioLoopTask = null;

            await ctx.Message.RespondAsync("Audio loop stopped").ConfigureAwait(false);
        }

        public async Task VoicePlayForce(CommandContext ctx, params string[] filename)
        {
            var voice = ctx.Client.GetVoiceNext();
            if (voice == null)
            {
                await ctx.Message.RespondAsync("Voice is not activated").ConfigureAwait(false);
                return;
            }

            var vnc = voice.GetConnection(ctx.Guild);
            if (vnc == null)
            {
                await ctx.Message.RespondAsync("Voice is not connected in this guild").ConfigureAwait(false);
                return;
            }

            var snd = string.Join(" ", filename);
            if (string.IsNullOrWhiteSpace(snd) || !File.Exists(snd))
            {
                await ctx.Message.RespondAsync("Invalid file specified").ConfigureAwait(false);
                return;
            }

            Exception exc = null;
            await ctx.Message.RespondAsync($"Playing `{snd}`").ConfigureAwait(false);
            try
            {
                // borrowed from
                // https://github.com/RogueException/Discord.Net/blob/5ade1e387bb8ea808a9d858328e2d3db23fe0663/docs/guides/voice/samples/audio_create_ffmpeg.cs

                var ffmpeg_inf = new ProcessStartInfo
                {
                    FileName = "ffmpeg",
                    Arguments = $"-i \"{snd}\" -ac 2 -f s16le -ar 48000 pipe:1",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                var ffmpeg = Process.Start(ffmpeg_inf);
                var ffout = ffmpeg.StandardOutput.BaseStream;

                var transmitStream = vnc.GetTransmitStream();
                await ffout.CopyToAsync(transmitStream).ConfigureAwait(false);
                await transmitStream.FlushAsync().ConfigureAwait(false);

                await vnc.WaitForPlaybackFinishAsync().ConfigureAwait(false);
            }
            catch (Exception ex) { exc = ex; }

            if (exc != null)
                throw exc;
        }
    }
}
