/*
 * Projekt där jag testar att skriva en egen loadbalancer 
 * Algorithmen jag tänker använda mig av är RoundRobin 
 * Varannan fråga till varannan server(server i detta fallet är bara Listor)
 * 
 * 
 * */
using LoadBalancer;
using LoadBalancer.FluentPolicyBuilder;

var test = new LoadBalancingHub();
/*List<HttpResponseMessage> requests = new List<HttpResponseMessage>();
for (int i = 0; i < 10; i++)
{
   requests.Add(test.BalanceLoad());
}*/
HttpRequestMessage req = new HttpRequestMessage();
req.RequestUri = new Uri("https://www.imdb.com/");
test.BalanceLoad(req);
test.BalanceLoad(req);
Console.WriteLine("HEHEHE");
var wrapper = new PolicyBuilder();
