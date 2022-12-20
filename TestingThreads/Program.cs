using RestaurantDesignPatterns;
using TestingThreads;

var test = new WorkDirector();
test.SetChefStatus();
ObjectToWorkON order = new ObjectToWorkON();
List<ObjectToWorkON> list = new List<ObjectToWorkON>();
for (int i = 0; i < 100; i++)
{
    list.Add(new ObjectToWorkON());
}

/*for (int i = 0; i < 20; i++)
{
    //test.EveryBodyWork($"DETTA JOBB BLEV ADDERAT TILL EN QUE{i}");
    string workOrder = $"Added work number {i}";
    WorkDirector.WorkOrdersToExecute.Enqueue(order);
}
for (int i = 0; i < 20; i++)
{
    test.EveryBodyWork("HE");
    Thread.Sleep(100);
}
Thread.Sleep(10);*/
for (int i = 0; i < list.Count; i++)
{
    //test.EveryBodyWork($"DETTA JOBB BLEV ADDERAT TILL EN QUE{i}");
    string workOrder = $"Added work number {i}";
    WorkDirector.WorkOrdersToExecute.Enqueue(list.ElementAt(i));
}
for (int i = 0; i < list.Count; i++)
{
    test.EveryBodyWork("HE");
    Thread.Sleep(100);
}
/*Action action = () =>
{
    test.EveryBodyWork("He");
   
};
Parallel.Invoke(action);
Thread.Sleep(10);*/
Console.WriteLine("SLUT");

test.PrintWorkOrdersNotManaged();
foreach (bool item in WorkDirector.HasTheThreadBeenTerminated)
{
    Console.WriteLine(item.ToString());
}

