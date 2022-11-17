namespace Core.Entities
{
    public class Product : BaseEntity
    {
        // * Product name
        public string Name { get; set; }

        // * Description
        public string Description { get; set; }

        // * Price
        public decimal Price { get; set; }

        // * Picture Url
        public string PictureUrl { get; set; }

        // * Product type
        public ProductType ProductType { get; set; }

        // * Product type id
        public int ProductTypeId { get; set; }

        // * Product brand
        public ProductBrand ProductBrand { get; set; }

        // * Product type id
        public int ProductBrandId { get; set; }
    }
}