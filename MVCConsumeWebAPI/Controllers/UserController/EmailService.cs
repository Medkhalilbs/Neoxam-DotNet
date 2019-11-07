//using EAGetMail;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace MVCConsumeWebAPI.Controllers
//{
//    public class EmailService : IDisposable
//    {

//        private static bool UpdateDatabase = false;
//        //private SampleEntities entities;

//        public EmailService(SampleEntities entities)
//        {
//            this.entities = entities;
//        }

//        public IList<Mail> GetAll()
//        {
//            var result = MessageController.liste;

            
//            return result;
//        }

//        public IEnumerable<Mail> Read()
//        {
//            return GetAll();
//        }

//        public void Create(Mail email)
//        {
//            if (!UpdateDatabase)
//            {
//                var first = GetAll().OrderByDescending(e => e.ReceivedDate).FirstOrDefault();
//                var id = (first != null) ? first.ProductID : 0;

//                email.ProductID = id + 1;

//                if (email.CategoryID == null)
//                {
//                    email.CategoryID = 1;
//                }

//                if (email.Category == null)
//                {
//                    email.Category = new CategoryViewModel() { CategoryID = 1, CategoryName = "Beverages" };
//                }

//                GetAll().Insert(0, email);
//            }
//            else
//            {
//                var entity = new Product();

//                entity.ProductName = email.ProductName;
//                entity.UnitPrice = email.UnitPrice;
//                entity.UnitsInStock = (short)email.UnitsInStock;
//                entity.Discontinued = email.Discontinued;
//                entity.CategoryID = email.CategoryID;

//                if (entity.CategoryID == null)
//                {
//                    entity.CategoryID = 1;
//                }

//                if (email.Category != null)
//                {
//                    entity.CategoryID = email.Category.CategoryID;
//                }

//                entities.Products.Add(entity);
//                entities.SaveChanges();

//                email.ProductID = entity.ProductID;
//            }
//        }

//        public void Update(Mail product)
//        {
//            if (!UpdateDatabase)
//            {
//                var target = One(e => e.ProductID == product.ProductID);

//                if (target != null)
//                {
//                    target.ProductName = product.ProductName;
//                    target.UnitPrice = product.UnitPrice;
//                    target.UnitsInStock = product.UnitsInStock;
//                    target.Discontinued = product.Discontinued;

//                    if (product.CategoryID == null)
//                    {
//                        product.CategoryID = 1;
//                    }

//                    if (product.Category != null)
//                    {
//                        product.CategoryID = product.Category.CategoryID;
//                    }
//                    else
//                    {
//                        product.Category = new CategoryViewModel()
//                        {
//                            CategoryID = (int)product.CategoryID,
//                            CategoryName = entities.Categories.Where(s => s.CategoryID == product.CategoryID).Select(s => s.CategoryName).First()
//                        };
//                    }

//                    target.CategoryID = product.CategoryID;
//                    target.Category = product.Category;
//                }
//            }
//            else
//            {
//                var entity = new Product();

//                entity.ProductID = product.ProductID;
//                entity.ProductName = product.ProductName;
//                entity.UnitPrice = product.UnitPrice;
//                entity.UnitsInStock = (short)product.UnitsInStock;
//                entity.Discontinued = product.Discontinued;
//                entity.CategoryID = product.CategoryID;

//                if (product.Category != null)
//                {
//                    entity.CategoryID = product.Category.CategoryID;
//                }

//                entities.Products.Attach(entity);
//                entities.Entry(entity).State = EntityState.Modified;
//                entities.SaveChanges();
//            }
//        }

//        public void Destroy(Mail product)
//        {
//            if (!UpdateDatabase)
//            {
//                var target = GetAll().FirstOrDefault(p => p.ProductID == product.ProductID);
//                if (target != null)
//                {
//                    GetAll().Remove(target);
//                }
//            }
//            else
//            {
//                var entity = new Product();

//                entity.ProductID = product.ProductID;

//                entities.Products.Attach(entity);

//                entities.Products.Remove(entity);

//                var orderDetails = entities.Order_Details.Where(pd => pd.ProductID == entity.ProductID);

//                foreach (var orderDetail in orderDetails)
//                {
//                    entities.Order_Details.Remove(orderDetail);
//                }

//                entities.SaveChanges();
//            }
//        }

//        public Mail One(Func<Mail, bool> predicate)
//        {
//            return GetAll().FirstOrDefault(predicate);
//        }

//        public void Dispose()
//        {
//            entities.Dispose();
//        }
//    }
//}