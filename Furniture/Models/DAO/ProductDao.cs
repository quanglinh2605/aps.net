using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;
namespace Models.DAO
{
    public class ProductDao
    {
        List<Product> products;
        Furniture db = null;
        public ProductDao()
        {          
            db = new Furniture();
        }

        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public IEnumerable<Product> listAll(string keyword, int page, int pagesize) 
        {
            var model = db.Products;
            if (!string.IsNullOrEmpty(keyword))
            {
                model.Where(x => x.Name.Contains(keyword));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pagesize);
        }

        public List<Product> listproduct(){
            return db.Products.ToList();
        }

        public List<Product> filterByPrice(long? idPrice,long cateId, long? cateDetailId)
        {
            products = new List<Product>();
            products = db.Products.Where(x => x.CategoryID == cateId).ToList();
            if (cateDetailId != null)
            {
                products = products.Where(x => x.CateDetailID == cateDetailId).ToList();
            }
            if (idPrice != null)
            {
                var filte = new PriceDao().getbyId(idPrice);
                products = products.Where(x => x.Price < filte.EndPrice && x.Price > filte.StartPrice).ToList();
            }
            return products;
        }

        public List<Product> listByProCateId(long id)
        {
            return products.Where(x => x.ProCateID == id).ToList();
        }

        public List<Product> listFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public List<Product> listRelatedProduct(long productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(X => X.ID != productId && X.CategoryID == product.CategoryID && X.CateDetailID == product.CateDetailID && X.ProCateID == product.ProCateID).OrderByDescending(x => x.CreateDate).ToList();
        }

        public List<Product> sortProduct(long value)
        {
            if (value == 8)
            {
                products = products.OrderByDescending(x => x.Price).ToList();
            }else if(value == 9)
            {
                products = products.OrderBy(x => x.Price).ToList();
            }else if(value == 10)
            {
                products = products.OrderByDescending(x => x.ViewCount).ToList();
            }
            return products;
        }

        public bool Update(Product entity)
        {
            var model = db.Products.Find(entity.ID);
            try
            {
                model.Image = entity.Image;
                model.Name = entity.Name;
                model.Price = entity.Price;
                model.PromotionPrice = entity.PromotionPrice;
                model.Quantity = entity.Quantity;
                model.Status = entity.Status;
                model.Size = entity.Size;
                model.Color = entity.Color;
                model.Material = entity.Material;
                model.State = entity.State;
                model.Design = entity.Design;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Product getByID(long id)
        {
            return db.Products.Find(id);
        }

        public bool Delete(long id)
        {
            db.Products.Remove(getByID(id));
            db.SaveChanges();
            return true;
        }

        public List<Product> loadMore(long? id, long? proId, int val, int count)
        {
            if (id != null)
            {
                products = products.Where(x => x.CateDetailID == id).ToList();
            }if (proId != null)
            {
                products = products.Where(x => x.ProCateID == proId).ToList();
            }
            int result = val + count;
            if(result < products.Count) { 
                return products.Take(result).ToList();
            }
            else
            {
                return products.ToList();
            }
        }

        public void updateImages(long productId, string images)
        {
            var product = db.Products.Find(productId);
            product.MoreImages = images;
            db.SaveChanges();
        }
    }
}
