namespace BLLgrocery.Mappers

{
    public class Mapper
    {
        public static BLmodel.BLuser ToBL(DALgrocery.DALmodels.User user)
        {
            return new BLmodel.BLuser
            {
                ID = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                Role = user.Role
            };
        }

        public static DALgrocery.DALmodels.User ToDAL(BLmodel.BLuser user)
        {
            return new DALgrocery.DALmodels.User
            {
                Id = user.ID,
                UserName = user.UserName,
                Password = user.Password,
                Role = user.Role
            };
        }

        // מ־DAL ל־BL
        public static BLmodel.BLsupplier ToBL(DALgrocery.DALmodels.Supplier supplier)
        {
            return new BLmodel.BLsupplier
            {
                ID = supplier.Id,
                CompanyName = supplier.CompanyName,
                PhoneNumber = supplier.PhoneNumber,
                RepresentativeName = supplier.RepresentativeName,
                Products = supplier.Products.Select(p => ToBL(p)).ToList() // ממפה את המוצרים אם יש
            };
        }

        // מ־BL ל־DAL
        public static DALgrocery.DALmodels.Supplier ToDAL(BLmodel.BLsupplier supplier)
        {
            return new DALgrocery.DALmodels.Supplier
            {
                Id = supplier.ID,
                CompanyName = supplier.CompanyName,
                PhoneNumber = supplier.PhoneNumber,
                RepresentativeName = supplier.RepresentativeName,
                Products = supplier.Products.Select(p => ToDAL(p)).ToList() // ממפה את המוצרים
            };
        }

        // Mapper למוצר (למקרה שהספקים כוללים מוצרים)
        public static BLmodel.BLproduct ToBL(DALgrocery.DALmodels.Product product)
        {
            return new BLmodel.BLproduct
            {
                Id = product.Id,
                Name = product.Name,
                PricePerItem = product.PricePerItem,
                minQuantity = product.minQuantity,
            };
        }

        public static DALgrocery.DALmodels.Product ToDAL(BLmodel.BLproduct product)
        {
            return new DALgrocery.DALmodels.Product
            {
                Id = product.Id,
                Name = product.Name,
                PricePerItem = product.PricePerItem,
                minQuantity = product.minQuantity,
            };
        }

        // מ־DAL ל־BL
 /*       public static BLmodel.BLorder ToBL(DALgrocery.DALmodels.Order order)
        {
            return new BLmodel.BLorder
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                Status = order.Status,
                SupplierId = order.SupplierId,
                Supplier = ToBL(order.Supplier),  // המפה גם את הספק אם צריך
                Items = order.Items.Select(i => ToBL(i)).ToList()  // ממפה את פריטי ההזמנה
            };
        }

        // מ־BL ל־DAL
        public static DALgrocery.DALmodels.Order ToDAL(BLmodel.BLorder order)
        {
            return new DALgrocery.DALmodels.Order
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                Status = order.Status,
                SupplierId = order.SupplierId,
                Supplier = ToDAL(order.Supplier),  // המפה גם את הספק אם צריך
                Items = order.Items.Select(i => ToDAL(i)).ToList()  // ממפה את פריטי ההזמנה
            };
        }*/
    }
}

