namespace ParkingGarage.BL
{
    public interface IParkingGarage<T, G>
    {
        public Task<T> ProcessRequest(G request);
    }

    public interface IParkingGarage<T>
    {
        public T ProcessRequest();
    }
}
