﻿using RoastedMarketplace.Core.Data;

namespace RoastedMarketplace.Data.Entity.Shop
{
    public class AvailableAttributeValue : FoundationEntity
    {
        public int AvailableAttributeId { get; set; }

        public string Value { get; set; }

        #region Virtual Properties
        public virtual AvailableAttribute AvailableAttribute { get; set; }
        #endregion

    }
}