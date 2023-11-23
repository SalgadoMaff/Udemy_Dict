Console.Write("Enter file name(with extension): ");
string fileName = Console.ReadLine();


var info = new DirectoryInfo(Environment.CurrentDirectory);

// Get "documents\\pdf":
var path = info.Parent.Parent.Parent.Parent.FullName + Path.DirectorySeparatorChar;

string[] line;
Dictionary<string,int> votes = new Dictionary<string,int>();
try
{
    using (StreamReader sr = File.OpenText(path+fileName))
    {
        while (!sr.EndOfStream)
        {
            line = sr.ReadLine().Split(';');

            if (votes.ContainsKey(line[0]))
            {
                votes[line[0]] += int.Parse(line[1]);
            }
            else
            {
                votes[line[0]] = int.Parse(line[1]);
            }            
        }
    }
    foreach(var vote in votes)
    {
        Console.WriteLine(vote.Key+": "+vote.Value);
    }
}
catch (IOException e)
{
    Console.WriteLine(e.Message);
}
