using System.Net.NetworkInformation;

public class NetworkInterfaceInfo
{
    private NetworkInterfaceType interfaceType;
    private long maxSpeed;
    private long bytesSent;
    private long bytesReceived;

    public NetworkInterfaceInfo(NetworkInterfaceType type)
    {
        interfaceType = type;
    }

    public void UpdateData()
    {
        NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface networkInterface in interfaces)
        {
            if (networkInterface.NetworkInterfaceType == interfaceType)
            {
                maxSpeed = networkInterface.Speed;
                bytesSent = networkInterface.GetIPv4Statistics().BytesSent;
                bytesReceived = networkInterface.GetIPv4Statistics().BytesReceived;
                break;
            }
        }
    }

    public override string ToString()
    {
        return $"Interface Type: {interfaceType}\nMax Speed: {maxSpeed} bps\nBytes Sent: {bytesSent}\nBytes Received: {bytesReceived}";
    }
}