using MeetupTask.DAL;
using MeetupTask.Models.Speaker;
using MeetupTask.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetupTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly SpeakerDB _context;


        public HomeController(SpeakerDB context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()  
        {
            return View(await _context.Speaker.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create( CreateSpeakerVM vm)
        {
            if (!ModelState.IsValid)
            {
            return View(vm);
            }

            Speaker speaker = new Speaker 
            {
                Name = vm.Name,
                Description = vm.Description,
                ImgUrl = vm.ImgUrl,
                SosialUrl1 = vm.SosialUrl1,
                SosialUrl2 = vm.SosialUrl2,
                SosialUrl3 = vm.SosialUrl3
            };

           await     _context.Speaker.AddAsync(speaker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id==null&& id<1)
            {
                return BadRequest();   
            }

           Speaker speaker=await _context.Speaker.FirstOrDefaultAsync(s=>s.Id==id);

            if (speaker==null) { return NotFound(); }

            UpdateSpeakerVM updateSpeakerVM = new UpdateSpeakerVM 
            {
            Description = speaker.Description,
            ImgUrl=speaker.ImgUrl,
            Name = speaker.Name,
            SosialUrl1=speaker.SosialUrl1,
            SosialUrl2=speaker.SosialUrl2,
            SosialUrl3 = speaker.SosialUrl3
            };

            return View(updateSpeakerVM);
        }


        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateSpeakerVM updateSpeakerVM) 
        {
            if (id==null &&id<1)
            {
                return BadRequest();
            }

            var exsited = await _context.Speaker.FirstOrDefaultAsync(s=>s.Id==id);

            if (exsited==null)
            {
                return BadRequest();
            }

            exsited.Description= updateSpeakerVM.Description;
            exsited.Name= updateSpeakerVM.Name;
            exsited.ImgUrl= updateSpeakerVM.ImgUrl;
            exsited.SosialUrl1 = updateSpeakerVM.SosialUrl1;
            exsited.SosialUrl2 = updateSpeakerVM.SosialUrl2;
            exsited.SosialUrl3 = updateSpeakerVM.SosialUrl3;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null && id<1)
            {
                return BadRequest();
            }

            var speaker = await _context.Speaker.FindAsync(id);
            if (speaker==null)
            {
                return NotFound();
            }

            _context.Speaker.Remove(speaker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }




    }
}
