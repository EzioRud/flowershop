using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShop
{
    public class Order : IOrder, IIdentified
    {
        private List<Flower> flowers;
        private bool isDelivered = false;
        public int Id { get; }

        // should apply a 20% mark-up to each flower.
        public double Price {
            get {
                return flowers.Sum(x > x.Cost * 2.0)
            }
        }

        public double Profit {
            get {
                return 0;
            }
        }

        public IReadOnlyList<IFlower> Ordered {
            get {
                return flowers.AsReadOnly();
            }
        }

        public IClient Client { get; private set; }

        public Order(IOrderDAO dao, IClient client)
        {
            this.flowers = new List<IFlower>();
            this.isDelivered = isDelivered();
            Client = Client;

            Id = dao.AddOrder(client);

        }

        // used when we already have an order with an Id.
        public Order(IOrderDAO dao, IClient client, bool isDelivered = false)
        {
            this.flowers = new List<Flower>();
            this.isDelivered = isDelivered;
            Client = client;
            Id = dao.AddOrder(client);
        }

        public void AddFlowers(IFlower flower, int n)
        {
            int i = 0;
            while (i < n)
            {
                flowers.Add(flower);
                i++;
            }
        }

        public void Deliver()
        {
            
        }
    }
}
