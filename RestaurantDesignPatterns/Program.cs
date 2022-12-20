// See https://aka.ms/new-console-template for more information
using RestaurantDesignPatterns;
using RestaurantDesignPatterns.Events;
using RestaurantDesignPatterns.WorkHub;

Menu menu = new Menu();
var items = menu.MenuItems;
var order1 = new Order();
order1.MenuItem = items.ElementAt(0);
order1.Count = 4;
order1.Status = OrderStatus.Waiting;
var order2 = new Order();
order2.MenuItem = items.ElementAt(1);
order2.Count = 2;
order2.Status = OrderStatus.Waiting;
var waiter1 = new Waiter();
waiter1.GetOrder(order1);
//var que = new OrderQue();
//que.AddOrder(order1);
var eventOrderCollector = new OrderCollector();
var distributurHub = new Distributor();
var chef = new Chef();

OrderQue.Instance.OrderAdded += distributurHub.OnOrderAdded;
//OrderQue.Instance.OrderAdded += chef2.OnOrderAdded;
//OrderQue.Instance.OrderAdded += chef2.OnOrderWorkPrepared;
distributurHub.DistributorChanged += chef.SendWorkToStart;
chef.DoneEvent += distributurHub.WorkDone;
for (int i = 0; i < 2; i++)
{
    OrderQue.Instance.AddOrder(order1);
    OrderQue.Instance.AddOrder(order2);

}
Thread.Sleep(1);

Console.WriteLine($"Vad finns kvar i våran mat kö ? : {OrderQue.Instance.Orders.Count} || Hur många maträtter har vi tilllagat? {Distributor.counter}");



//Console.WriteLine("NU HAR ORDEN GÅTT IVÄG OCH GÖR SIN GREJJ OCH SYSTEMET ÄR REDO FÖR NYA UPPDRAG");
var printUi = new UI();
printUi.PrintUI();
Console.WriteLine($"Vad finns kvar i våran mat kö ? : {OrderQue.Instance.Orders.Count} || Hur många maträtter har vi tilllagat? {Distributor.counter}");
Ticket.PrintSales();
//OKEJ SÅ NU ÄR NÄSTA PROBLEM JAG MÅSTE SE TiLL ATT JAG INTE PLOCKAR SAMMA JOBB TVÅ GÅNGER???????
