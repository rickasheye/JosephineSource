using System;
using Humanizer.Localisation.CollectionFormatters;

namespace Humanizer.Configuration
{
	// Token: 0x0200007C RID: 124
	internal class CollectionFormatterRegistry : LocaliserRegistry<ICollectionFormatter>
	{
		// Token: 0x06000258 RID: 600 RVA: 0x0000D6AC File Offset: 0x0000B8AC
		public CollectionFormatterRegistry() : base(new DefaultCollectionFormatter("&"))
		{
			base.Register("en", new OxfordStyleCollectionFormatter("and"));
			base.Register("it", new DefaultCollectionFormatter("e"));
			base.Register("de", new DefaultCollectionFormatter("und"));
			base.Register("dk", new DefaultCollectionFormatter("og"));
			base.Register("nl", new DefaultCollectionFormatter("en"));
			base.Register("pt", new DefaultCollectionFormatter("e"));
			base.Register("ro", new DefaultCollectionFormatter("și"));
			base.Register("nn", new DefaultCollectionFormatter("og"));
			base.Register("nb", new DefaultCollectionFormatter("og"));
			base.Register("sv", new DefaultCollectionFormatter("och"));
		}
	}
}
