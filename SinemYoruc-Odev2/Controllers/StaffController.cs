using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinemYoruc_Odev2.Controllers
{

    [Route("[controller]s")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        List<Staff> list = new(); //Staff turunde yeni nesne olusturuldu
        public StaffController()
        {
            list.Add(new Staff { Id = 1, Name = "Deny", Lastname = "Sellen", DateOfBirth = new DateTime(1989, 01, 01).ToShortDateString(), Email = "deny@gmail.com", PhoneNumber = "+90555443366", Salary = 4450 }); //Listeye eleman eklendi
        }
        private ActionResult<List<Staff>> GetList() //Listenin elemanlarini almasi icin genel bir method yazildi
        {
            return new ActionResult<List<Staff>>(list);
        }


        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<Staff>> GetAll() //Listenin tum elemanlarini getiren Get methodu 
        {
            return GetList();
        }


        [HttpGet("GetById/{id}")]
        public ActionResult<Staff> GetById([FromRoute] long id) //id'ye gore listenin istenen elemanini getiren GetById methodu
        {
            ActionResult<List<Staff>> list = GetList();  //listenin elemanlari alindi
            Staff staff = list.Value.Where(x => x.Id == id).FirstOrDefault(); //staffin id'si alindi
            if(staff == null)
            {
                return NotFound();
            }
            return new ActionResult<Staff>(staff); //id'si alinan staff donduruldu
        }


        [HttpPost]
        public ActionResult<List<Staff>> CreateStaff([FromBody] Staff staff) //Yeni staff ekleyen Post methodu
        {
            var list = GetList().Value; //listenin elemanlari alindi
            list.Add(staff); //staff eklendi
            return new ActionResult<List<Staff>>(list); //Yeni liste donduruldu
        }

        [HttpPut]
        public ActionResult<List<Staff>> UpdateStaff(int id, [FromBody] Staff updateStaff) //Staff guncelleyen Put methodu
        {
            List<Staff> list = GetList().Value; //listenin elemanlari alindi
            Staff staff = list.Where(x => x.Id == id).FirstOrDefault(); //Guncellenecek staffin idsi alindi
            list.Remove(staff); //Mevcut staff silindi
            updateStaff.Id = id; //girilen id ile yeni staffin idsi esitlendi
            list.Add(updateStaff); //yeni staff listeye eklendi
            return new ActionResult<List<Staff>>(list.ToList()); //Yeni liste donduruldu
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Staff>> DeleteStaff([FromRoute] int id)
        {
            List<Staff> list = GetList().Value; //listenin elemanlari alindi
            Staff staff = list.Where(x => x.Id == id).FirstOrDefault(); //silinecek staffin idsi alindi
            list.Remove(staff); //silme islemi
            return new ActionResult<List<Staff>>(list); //Yeni liste donduruldu
        }
    }
}
