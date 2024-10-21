using AutoMapper;
using ElhawaryApi.DI.Interfaces;
using ElhawaryApi.DI.Services;
using ElhawaryApi.Events;
using ElhawaryApi.Models.Domain;

namespace ElhawaryApi.Controllers
{
    
    public class MaintenanceController : Controller
    {
        private readonly IMaintenanceService _maintenanceService;
        private readonly IMapper Mapper;
        private readonly MaintenanceEventHandler _maintenanceEventHandler;
        public MaintenanceController(IMaintenanceService maintenanceService, IMapper mapper, MaintenanceEventHandler maintenanceEventHandler)
        {
            _maintenanceService = maintenanceService;
            _maintenanceEventHandler = maintenanceEventHandler;
            Mapper = mapper;

            // REGISTER TO EVENT
            _maintenanceService.MaintenanceCreated += _maintenanceEventHandler.OnMaintenanceCreated;
        }



        [HttpGet]
        [Route("/api/maintenance")]
        //[Authorize(Roles = "Owner, Admin")]
        public async Task<ActionResult<List<MaintenanceDTO>>> GetMaintenanceList()
        {
            var list = await _maintenanceService.GetMaintenanceList();

            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        [HttpGet]
        [Route("/api/maintenance/{id}")]
        //[Authorize(Roles = "Owner, Admin")]
        public async Task<ActionResult<MaintenanceDTO>> GetMaintenanceById(int id)
        {
            Maintenance maintenace = await _maintenanceService.GetMaintenanceById(id) ?? throw new Exception("No data found");
            if (maintenace != null)
            {
                MaintenanceDTO dto = new()
                {
                    Id = maintenace.Id,
                    CustomerName = maintenace.CustomerName,
                    CustomerPhoneNumber = maintenace.CustomerPhoneNumber,
                    DeviceModel = maintenace.DeviceModel,
                    IssueType = maintenace.IssueType,
                    IssueFees = maintenace.IssueFees,
                    RecievedAt = maintenace.RecievedAt,
                    Notes = maintenace.Notes,
                    MaintenanceType = maintenace.MaintenanceType
                };

                return Ok(dto);
            }
            else
            {
                return NotFound("No data found!");
            }
        }

        [HttpPost]
        [Route("/api/maintenance/new")]
        //[Authorize(Roles = "Owner, Admin")]
        public async Task<ActionResult> AddNewDeviceToMaintenance(MaintenanceDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _maintenanceService.AddNewDeviceToMaintenance(dto);
            return Ok();
        }

        #region
        //[Authorize(Roles = "Owner")]
        //[HttpPost]
        //public async Task<ActionResult> DeleteMaintenace(int? id)
        //{
        //    Maintenance maintenance = await _maintenanceService.GetMaintenanceById(id);

        //    if(maintenance == null)
        //    {
        //        return BadRequest();
        //    }

        //    bool deleted = await _maintenanceService.DeleteMaintenance(id);

        //    if(!deleted)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok();
        //}
        #endregion

        [HttpPatch]
        [Route("/api/maintenance/{id}")]
        //[Authorize(Roles = "Owner, Admin")]
        public async Task<ActionResult> UpdateMaintenance([FromRoute] int id, MaintenanceDTO dto)
        {
            var maintenance = await _maintenanceService.GetMaintenanceById(id);

            if(maintenance == null)
            {
                return NotFound("No data found");
            }
            
            //if (!ModelState.IsValid)
            //{
            //    dto.CustomerName = maintenance.CustomerName;
            //    dto.CustomerPhoneNumber = maintenance.CustomerPhoneNumber;
            //    dto.DeviceModel = maintenance.DeviceModel;
            //    dto.IssueFees = maintenance.IssueFees;
            //    dto.IssueType = maintenance.IssueType;
            //    dto.PieceOrginalFee = maintenance.PieceOrginalFee;
            //    dto.StatusId = maintenance.StatusId;
            //    dto.MaintenanceType = maintenance.MaintenanceTypeId == 1 ? "Hardware" : "Software";
            //    dto.RecievedAt = maintenance.RecievedAt;
            //    dto.Notes = maintenance.Notes;
            //}

            await _maintenanceService.UpdateMaintenance(id, dto);
            return Ok("Updated successfuly");
        }

        [HttpDelete]
        [Route("/api/maintenance/{id}")]
        //[Authorize(Roles = "Owner")]
        public async Task<ActionResult> DeleteMaintenace(int? id)
        {
            if (id == null)
                return BadRequest();

            return await _maintenanceService.DeleteMaintenance(id) ? Ok() : NotFound();
        }
    }
}
