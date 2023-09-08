
using System;
using System.IO;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Создать новый XML файл");
            Console.WriteLine("2. Открыть XML файл");
            Console.WriteLine("3. Редактировать XML файл");
            Console.WriteLine("4. Сохранить XML файл");
            Console.WriteLine("5. Выход");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateXmlFile();
                    break;
                case "2":
                    OpenXmlFile();
                    break;
                case "3":
                    EditXmlFile();
                    break;
                case "4":
                    SaveXmlFile();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                    break;
            }
        }
    }

    private static XmlDocument xmlDoc = new XmlDocument();
    private static string xmlFilePath = "";

    private static void CreateXmlFile()
    {
        XmlDocument doc = new XmlDocument();

        XmlElement root = doc.CreateElement("root");
        doc.AppendChild(root);

        XmlElement child1 = doc.CreateElement("child1");
        child1.InnerText = "Hello";
        root.AppendChild(child1);

        XmlElement child2 = doc.CreateElement("child2");
        child2.InnerText = "World";
        root.AppendChild(child2);

        string filePath = "example.xml";
        string fullPath = Path.GetFullPath(filePath);
        Console.WriteLine("Путь созданного XML-файла: " + fullPath);
        doc.Save(filePath);

        xmlDoc = doc; 
        xmlFilePath = filePath; 

        Console.WriteLine("XML-файл создан!");
    }

    private static void OpenXmlFile()
    {
        Console.Write("Введите путь к XML файлу: ");
        xmlFilePath = Console.ReadLine();

        try
        {
            xmlDoc.Load(xmlFilePath);
            Console.WriteLine("XML файл успешно загружен.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при загрузке XML файла: " + ex.Message);
        }
    }

    private static void EditXmlFile()
    {
        if (xmlDoc.DocumentElement == null)
        {
            Console.WriteLine("XML файл не загружен. Сначала загрузите файл.");
            return;
        }

        Console.WriteLine("Текущее содержимое XML файла:");
        Console.WriteLine(xmlDoc.InnerXml);

        Console.WriteLine("Введите новое XML содержимое:");
        string newXmlContent = Console.ReadLine();

        try
        {
            xmlDoc.LoadXml(newXmlContent);
            Console.WriteLine("XML файл успешно отредактирован.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при редактировании XML файла: " + ex.Message);
        }
    }

    private static void SaveXmlFile()
    {
        if (xmlDoc.DocumentElement == null)
        {
            Console.WriteLine("XML файл не загружен. Сначала загрузите файл.");
            return;
        }

        if (string.IsNullOrEmpty(xmlFilePath))
        {
            Console.Write("Введите путь для сохранения XML файла: ");
            xmlFilePath = Console.ReadLine();
        }

        try
        {
            xmlDoc.Save(xmlFilePath);
            Console.WriteLine("XML файл успешно сохранен.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при сохранении XML файла: " + ex.Message);
        }
    }
}