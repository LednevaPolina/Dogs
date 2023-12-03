using Dogs.Helpers;
using Dogs.Models;
using Dogs.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Dogs.Extensions;
using System.Drawing;

namespace Dogs.Controllers
{
    public class DogController:Controller
    {
        private readonly DogDbContext dogDbContext;

        public DogController(DogDbContext dogDbContext) 
        {
            this.dogDbContext = dogDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.tags = new MultiSelectList(dogDbContext.Tag, "Id", "Name");
            return View();
        }
        [HttpGet]
        public IActionResult Index()
        {
            
            var dogs=dogDbContext.Dogs;
            var tags=dogDbContext.Tag;

            var model=new IndexViewModel() { Dogs = dogs, Tags = tags };
            return View(model);
        }
        public IActionResult FCI1()
        {
            var dogs = dogDbContext.Dogs;
            return View(dogs);
        }
        public IActionResult FCI2()
        {
            var dogs = dogDbContext.Dogs;
            return View(dogs);
        }
        public IActionResult FCI3()
        {
            var dogs = dogDbContext.Dogs;
            return View(dogs);
        }
        public IActionResult FCI4()
        {
            var dogs = dogDbContext.Dogs;
            return View(dogs);
        }
        public IActionResult FCI5()
        {
            var dogs = dogDbContext.Dogs;
            return View(dogs);
        }
        public IActionResult FCI6()
        {
            var dogs = dogDbContext.Dogs;
            return View(dogs);
        }
        public IActionResult FCI7()
        {
            var dogs = dogDbContext.Dogs;
            return View(dogs);
        }
        public IActionResult FCI8()
        {
            var dogs = dogDbContext.Dogs;
            return View(dogs);
        }
        public IActionResult FCI9()
        {
            var dogs = dogDbContext.Dogs;
            return View(dogs);
        }
        public IActionResult FCI10()
        {
            var dogs = dogDbContext.Dogs;
            return View(dogs);
        }
        public IActionResult FCI0()
        {
            var dogs = dogDbContext.Dogs;
            return View(dogs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Dog dog, IFormFile Image, int[]tags)
        {

            dog.ImageUrl = await FileUploadHelper.UploadAsync(Image);                    

            TempData["status"] = "Великолепно! Добавлена новая порода!";            
            await dogDbContext.Dogs.AddAsync(dog);
            await dogDbContext.SaveChangesAsync();
            //foreach (var dogTag in tags)
            //{
            //    var tmpDogTag = new DogTag() { DogId = dog.Id, TagId = dogTag };
            //    dogDbContext.DogTags.Add(tmpDogTag);
            //    await dogDbContext.SaveChangesAsync();
            //}
            dogDbContext.DogTags.AddRange(tags.Select(a =>  new DogTag() { DogId = dog.Id, TagId = a }));
            await dogDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        
            return View(dog);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {

            var dogs = dogDbContext.Dogs
                .Include(x => x.DogTags).ThenInclude(x => x.Tag)
                .FirstOrDefault(dogs => dogs.Id == id);
            return View(dogs);
        }
        [HttpGet]
        public async Task<IActionResult>Edit(int id)
        {
            var dogs = dogDbContext.Dogs.Find(id);

            //ViewBag.categories = new SelectList(dogDbContext.Categories, "Id", "Name");

            var selectedTagIds = dogDbContext.DogTags.Where(x => x.DogId == id).Select(x => x.TagId);
            ViewBag.tags = new MultiSelectList(dogDbContext.Tag, "Id", "Name", selectedTagIds);            

            return View(dogs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Dog dog, IFormFile Image, int[] tags)
        {
            if (Image != null)
            {
                var path = await FileUploadHelper.UploadAsync(Image);
                dog.ImageUrl = path;
            }

            dogDbContext.Dogs.Update(dog);
            await dogDbContext.SaveChangesAsync();


            var postWithTags = dogDbContext.Dogs.Include(x =>x.DogTags).FirstOrDefault(x => x.Id == dog.Id);
            int a = 0;
            dogDbContext.UpdateManyToMany(
                postWithTags.DogTags,
                tags.Select(x => new DogTag { DogId = dog.Id, TagId = x }),
                x => x.TagId
                );
            await dogDbContext.SaveChangesAsync();

           

            return RedirectToAction("Index");
        }

    }
}
