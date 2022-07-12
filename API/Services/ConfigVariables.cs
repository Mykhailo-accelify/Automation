namespace API.Services
{
    using API.Interfaces;

    public class ConfigVariables
    {
        //Service
        internal static string RebbitMQVirtualHost = nameof(RebbitMQVirtualHost);
        internal static string Domain = nameof(Domain);
        internal static string SubDomain = nameof(SubDomain);
        internal static string RootDomain = nameof(RootDomain);
        internal static string ImportProduct = "ImportTool";

        internal static string NetworkLetterSequence = nameof(NetworkLetterSequence);
        internal static string NetworkLetterCurrent = nameof(NetworkLetterCurrent);        

        //Suffix
        internal static string VirtualHostSuffix = nameof(VirtualHostSuffix);
        internal static string DatabaseNameSuffix = nameof(DatabaseNameSuffix);

        //Xpath
        internal static string DatabaseNameXPath = nameof(DatabaseNameXPath);
        internal static string VirtualHostXPath = nameof(VirtualHostXPath);
        internal static string DiskNameXPath = nameof(DiskNameXPath);
        internal static string DestinationIPXPath = nameof(DestinationIPXPath);
        internal static string DestinationUserXPath = nameof(DestinationUserXPath);
        internal static string NetworkPathXPath = nameof(NetworkPathXPath);
        internal static string DatabaseServerXPath = nameof(DatabaseServerXPath);
        internal static string JobMachineNameXPath = nameof(JobMachineNameXPath);
        internal static string ImportToolJobMachineNameXPath = nameof(ImportToolJobMachineNameXPath);
        internal static string AutoImportPathXPath = nameof(AutoImportPathXPath);
        internal static string RabbitWorkerMachineIPXPath = nameof(RabbitWorkerMachineIPXPath);
        internal static string RabbitWorkerMachineUserXPath = nameof(RabbitWorkerMachineUserXPath);

        //Path
        internal static string StatePath = nameof(StatePath);
        internal static string State504Path = nameof(State504Path);
        internal static string CustomerEnvironmentPath = nameof(CustomerEnvironmentPath);
        internal static string EnvironmentCommonPath = nameof(EnvironmentCommonPath);

        //Type 
        internal static string DBListenerType = nameof(DBListenerType);
        internal static string RabbitType = nameof(RabbitType);
        internal static string IISType = nameof(IISType);
        internal static string IISImportToolType = nameof(IISImportToolType);
        internal static string LoadBalancerWebType = nameof(LoadBalancerWebType);
        internal static string LoadBalancerImportType = nameof(LoadBalancerImportType);
        internal static string FSXType = nameof(FSXType);
        internal static string WorkerType = nameof(WorkerType);

        //Template
        internal static string DomainTemplate = nameof(DomainTemplate);
        internal static string SiteNameTemplate = nameof(SiteNameTemplate);
        internal static string ImportToolSiteNameTemplate = nameof(ImportToolSiteNameTemplate);
        internal static string VirtualHostTemplate = nameof(VirtualHostTemplate);
        internal static string DatabaseNameTemplate = nameof(DatabaseNameTemplate);
        internal static string NetworkPathTemplate = nameof(NetworkPathTemplate);   
        
        //Placehodler
        internal static string FSXPlacehodler = "{FSX}";
    }
}
