
using System.Xml.Serialization;
using System.Xml;
using System.Text;




const string path = @"C:\VisualStudioProj\Consoleapps\Consoleapps\SerializeIt\person.xml";
if(File.Exists(path)){
    using Stream stream = File.OpenRead(path);
     var serializer = new XmlSerializer(typeof(Person));
    
    using StreamReader streamReader = new StreamReader(stream,Encoding.UTF8);
    var personre = (Person?)serializer.Deserialize(new XmlTextReader(streamReader));
    Console.WriteLine($"Person name:  {personre.Name}");

}
else{
 var name = Read("name");
var lastname = Read("lastname");
var hobby = Read("hobby");

var person = new Person(name,lastname,hobby);
string xml = Serialize(person);
Console.WriteLine(xml);
SaveToFile(xml,@"C:\VisualStudioProj\Consoleapps\Consoleapps\SerializeIt\person.xml");

static void SaveToFile(string xml,string path){
File.WriteAllText(path,xml);
}

}

static string Read(string name){
Console.WriteLine($"Enter the {name}");
return Console.ReadLine();
}
 static string Serialize(Person person){
XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
using var stringwriter = new StringWriter();
using var xmlWriter  = XmlWriter.Create(stringwriter,new XmlWriterSettings{Indent=true});
xmlSerializer.Serialize(xmlWriter,person);
return stringwriter.ToString();
}

public record Person{

    public string Name { get; set; }
    public string Lastname{get;set;}
    public string Hobby { get; set; }

public Person(){

}
    public Person(string name,string lastname,string hobby){
        Name=name;
        Lastname=lastname;
        Hobby=hobby;

    }
    
    
    
}