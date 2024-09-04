using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Model
{
    //Đơn mua 
    internal class Product : Base
    {
        private uint furnitureID;
        private uint sizeID;
        private uint shapeID;
        private uint materialID;
        private uint manufacturerID;
        private string usageID;
        private string featureID;
        private uint colorID;
        private uint countryOriginID;
        private uint quantity;
        private uint purchasePrice;
        private uint salePrice;
        private uint warrantyTime;
        private string image;
        private string note;

        public uint FurnitureID { get => furnitureID; set => furnitureID=value; }
        public uint SizeID { get => sizeID; set => sizeID=value; }
        public uint ShapeID { get => shapeID; set => shapeID=value; }
        public uint MaterialID { get => materialID; set => materialID=value; }
        public uint ManufacturerID { get => manufacturerID; set => manufacturerID=value; }
        public string UsageID { get => usageID; set => usageID=value; }
        public string FeatureID { get => featureID; set => featureID=value; }
        public uint ColorID { get => colorID; set => colorID=value; }
        public uint CountryOriginID { get => countryOriginID; set => countryOriginID=value; }
        public uint Quantity { get => quantity; set => quantity=value; }
        public uint PurchasePrice { get => purchasePrice; set => purchasePrice=value; }
        public uint SalePrice { get => salePrice; set => salePrice=value; }
        public uint WarrantyTime { get => warrantyTime; set => warrantyTime=value; }
        public string Image { get => image; set => image=value; }
        public string Note { get => note; set => note=value; }

        public Product() : base()
        {
            FurnitureID = 0;
            SizeID = 0;
            ShapeID = 0;
            MaterialID = 0;
            ManufacturerID = 0;
            UsageID = "";
            FeatureID = "";
            ColorID = 0;
            CountryOriginID = 0;
            Quantity = 0;
            PurchasePrice = 0;
            SalePrice = 0;
            WarrantyTime = 0;
            Image = "";
            Note = "";
        }

        public Product(uint id, string name, uint furnitureID, uint sizeID, uint shapeID, uint materialID, 
            uint manufacturerID, string usage, string featureID, uint colorID, uint countryOriginID, uint quantity, 
            uint purchasePrice, uint salePrice, uint warrantyTime, string image, string note) : base(id, name)
        {
            FurnitureID=furnitureID;
            SizeID=sizeID;
            ShapeID=shapeID;
            MaterialID=materialID;
            ManufacturerID=manufacturerID;
            UsageID=usage??throw new ArgumentNullException(nameof(usage));
            FeatureID=featureID??throw new ArgumentNullException(nameof(featureID));
            ColorID=colorID;
            CountryOriginID=countryOriginID;
            Quantity=quantity;
            PurchasePrice=purchasePrice;
            SalePrice=salePrice;
            WarrantyTime=warrantyTime;
            Image=image??throw new ArgumentNullException(nameof(image));
            Note=note;
        }
    }
}
