using ArduinoTemperatureAPI;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TemperatureController : ControllerBase
{
    private readonly AppDbContext _context;

    public TemperatureController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("insert_temperature")]
    public async Task<IActionResult> InsertTemperature([FromForm] decimal temperatura)
    {
        if (temperatura < -50 || temperatura > 50) // Validación simple para el rango de temperatura
            return BadRequest("Temperatura inválida");

        var record = new TemperatureRecord
        {
            fecha = DateTime.UtcNow,
            temperatura = temperatura
        };

        try
        {
            _context.temperatura.Add(record);
            await _context.SaveChangesAsync();
            return Ok(record);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al insertar los datos: {ex.Message}");
        }
    }
}
