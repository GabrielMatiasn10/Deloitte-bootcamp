using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.Models;
using MinhaApi.Dtos;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/LotesMinerio")] 
    public class LotesMinerioController : ControllerBase
    {
        private readonly AppDbContext _db;

        public LotesMinerioController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/LotesMinerio
        [HttpGet] 
        public async Task<IActionResult> GetAll()
        {
            var lotes = await _db.LotesMinerio.AsNoTracking().ToListAsync();

            var response = lotes.Select(l => new LoteMinerioResponseDto(
                l.Id, l.CodigoLote, l.MinaOrigem, l.TeorFe, l.Umidade, l.SiO2, l.P,
                l.Toneladas, l.DataProducao, l.Status, l.LocalizacaoAtual
            ));

            return Ok(response);
        }

        // GET: api/LotesMinerio/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var l = await _db.LotesMinerio.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            
            if (l is null) return NotFound();

            var dto = new LoteMinerioResponseDto(
                l.Id, l.CodigoLote, l.MinaOrigem, l.TeorFe, l.Umidade, l.SiO2, l.P,
                l.Toneladas, l.DataProducao, l.Status, l.LocalizacaoAtual
            );

            return Ok(dto);
        }

        // POST: api/LotesMinerio
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLoteMinerioDto input)
        {
            if (string.IsNullOrWhiteSpace(input.CodigoLote)) return BadRequest("CodigoLote obrigatório.");

            var exists = await _db.LotesMinerio.AnyAsync(x => x.CodigoLote == input.CodigoLote);
            if (exists) return Conflict("Lote já existe.");

            var lote = new LoteMinerio
            {
                CodigoLote = input.CodigoLote,
                MinaOrigem = input.MinaOrigem,
                TeorFe = input.TeorFe,
                Umidade = input.Umidade,
                SiO2 = input.SiO2,
                P = input.P,
                Toneladas = input.Toneladas,
                DataProducao = DateTime.SpecifyKind(input.DataProducao ?? DateTime.UtcNow, DateTimeKind.Utc),
                Status = (StatusLote)input.Status,
                LocalizacaoAtual = input.LocalizacaoAtual
            };

            _db.LotesMinerio.Add(lote);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = lote.Id }, lote);
        }

        // --- NOVO MÉTODO PUT: api/LotesMinerio/{id} ---
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateLoteMinerioDto input)
        {
            var lote = await _db.LotesMinerio.FirstOrDefaultAsync(x => x.Id == id);
            
            if (lote is null) return NotFound("Lote não encontrado para atualização.");

            // Atualizando os campos
            lote.MinaOrigem = input.MinaOrigem;
            lote.TeorFe = input.TeorFe;
            lote.Umidade = input.Umidade;
            lote.SiO2 = input.SiO2;
            lote.P = input.P;
            lote.Toneladas = input.Toneladas;
            lote.Status = (StatusLote)input.Status;
            lote.LocalizacaoAtual = input.LocalizacaoAtual;
            
            // Caso queira permitir mudar a data
            lote.DataProducao = DateTime.SpecifyKind(input.DataProducao ?? lote.DataProducao, DateTimeKind.Utc);

            await _db.SaveChangesAsync();

            return NoContent(); // Retorno padrão para sucesso em PUT (204 No Content)
        }

        // --- NOVO MÉTODO DELETE: api/LotesMinerio/{id} ---
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var lote = await _db.LotesMinerio.FirstOrDefaultAsync(x => x.Id == id);
            
            if (lote is null) return NotFound("Lote não encontrado para exclusão.");

            _db.LotesMinerio.Remove(lote);
            await _db.SaveChangesAsync();

            return Ok(new { message = $"Lote {id} removido com sucesso." });
        }
    }
}