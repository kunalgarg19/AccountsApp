
namespace Zip.Accounts.Core.Common
{
    public interface IDto
    {
        int Id { get; set; }
    }

    public abstract class BaseDto: IDto
    {
        public int Id { get; set; }
    }
}
