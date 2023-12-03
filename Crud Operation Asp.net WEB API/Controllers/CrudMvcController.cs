using Crud_Operation_Asp.net_WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Crud_Operation_Asp.net_WEB_API.Controllers
{
    public class CrudMvcController : Controller
    {
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<Student> std_list = new List<Student>();
            client.BaseAddress = new Uri("https://localhost:44390/api/");
            var response = client.GetAsync("CrudApi");
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Student>>();
                display.Wait();
                std_list = display.Result;
            }
            return View(std_list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            client.BaseAddress = new Uri("https://localhost:44390/api/");
            var response = client.PostAsJsonAsync<Student>("CrudApi", s);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View();
        }

        public async Task<ActionResult> Details(int id)
        {
            Student s = null;
            client.BaseAddress = new Uri("https://localhost:44390/api/");
            var response = await client.GetAsync("CrudApi?id=" + id.ToString());


            if (response.IsSuccessStatusCode)
            {
                var display = await response.Content.ReadAsAsync<Student>();
                s = display;
            }
            return View(s);
        }
        public async Task<ActionResult> Edit(int id)
        {
            Student s = null;
            client.BaseAddress = new Uri("https://localhost:44390/api/");
            var response = await client.GetAsync("CrudApi?id=" + id.ToString());
            if (response.IsSuccessStatusCode)
            {
                var display = await response.Content.ReadAsAsync<Student>();
                s = display;
            }
            return View(s);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Student s)
        {

            client.BaseAddress = new Uri("https://localhost:44390/api/");
            var response = await client.PutAsJsonAsync<Student>("CrudApi", s);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View("Edit");
        }


        public async Task<ActionResult> Delete(int id)
        {
            Student s = null;
            client.BaseAddress = new Uri("https://localhost:44390/api/");
            var response = await client.GetAsync("CrudApi?id=" + id.ToString());
            if (response.IsSuccessStatusCode)
            {
                var display = await response.Content.ReadAsAsync<Student>();
                s = display;
            }
            return View(s);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44390/api/");
            var response = await client.DeleteAsync("CrudApi?id=" + id.ToString());
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View("Delete");

        }
    }
}