namespace PaymentAPI.Tests;

public class VendaControllerTest
{
  private ApiContext _context;
  private VendaController _controller;

  [SetUp]
  public void Setup()
  {
    var options = new DbContextOptionsBuilder<ApiContext>().UseInMemoryDatabase("PaymentAPI_Test").Options;
    _context = new ApiContext(options);
    _controller = new VendaController(_context);
  }

  [Test]
  public void RegistrarVenda_DeveRetornarOK()
  {
  }
}
