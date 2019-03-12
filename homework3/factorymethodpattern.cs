
/*工厂方法模式*/

using System;

public interface Logger
{
    void writelog();
}

public interface Factory
{
    Logger createlogger();
}

public class Databaselogger : Logger
{
    public void writelog()
    {
        Console.Write("数据库日志\n");
    }
    public Databaselogger()
    {
        Console.Write("生成数据库日志\n");
    }
}

public class Filelogger : Logger
{
    public void writelog()
    {
        Console.Write("文件日志\n");
    }
    public Filelogger()
    {
        Console.Write("生成文件日志\n");
    }
}

public class Filefactory : Factory
{
    public Logger createlogger()
    {
        Logger logger = new Databaselogger();
        return logger;
    }
}

public class Datafactory : Factory
{
    public Logger createlogger()
    {
        Logger logger = new Filelogger();
        return logger;
    }
}

public class Client
{
    public static void Main()
    {
        Factory loggerfactory = new Datafactory();
        Logger datalogger = loggerfactory.createlogger();
        datalogger.writelog();
        Factory loggerfactory2 = new Filefactory();
        Logger filelogger = loggerfactory2.createlogger();
        filelogger.writelog();
        return;
    }
}