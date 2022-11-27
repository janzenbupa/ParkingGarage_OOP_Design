namespace ParkingGarage.BL
{
    public interface IParkingGarage<T, G>
    {
        public T ProcessRequest(G request);
    }

    public interface IParkingGarage<T>
    {
        public T ProcessRequest();
    }
}
