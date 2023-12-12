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
            ViewBag.fciCategories = new SelectList(dogDbContext.FCICategories, "Id", "Name");
            ViewBag.tags = new MultiSelectList(dogDbContext.Tags, "Id", "Name");
            return View();
        }
        [HttpGet]

        public IActionResult Index( string? searchBreed=null,int? tagId=null,int? fciCategoryId=null,int page=1)
        {
            
            var dogs=dogDbContext.Dogs.Include(x=>x.DogTags).ThenInclude(x=>x.Tag).Include(x=>x.FCICategory).OrderBy(x=>x.Breed);
            if(searchBreed !=null)
            {
                dogs = (IOrderedQueryable<Dog>)dogs.Where(x => x.Breed == searchBreed);
            }
        
            if(fciCategoryId != null && tagId !=null)
            {
                dogs = (IOrderedQueryable<Dog>)dogs.Where(x => x.FCICategoryId == fciCategoryId && x.DogTags.All (x => x.TagId == tagId));
            }
            else if(fciCategoryId!=null)
            {
                dogs= (IOrderedQueryable<Dog>)dogs.Where(x=>x.FCICategoryId==fciCategoryId);
            }
            else if (tagId != null)
            {
                 dogs = (IOrderedQueryable<Dog>)dogs.Where(x=>x.DogTags.Any(x=>x.TagId==tagId));
            }

            var model = new IndexViewModel();
            int totalP = (int)Math.Ceiling(dogs.Count() / (double)model.LimitPage);
            dogs = (IOrderedQueryable<Dog>)dogs.Skip((page - 1) * model.LimitPage).Take(model.LimitPage);
            model.Dogs = dogs;
            model.Tags = dogDbContext.Tags;
            model.FCICategories = dogDbContext.FCICategories;
            model.RecentDogs = dogDbContext.Dogs.OrderByDescending(x => x.Id).Take(3);
            model.CurrentPages = page;
            model.TotalPages = totalP;
            model.SelectedFCICategoryId = fciCategoryId;
            model.SelectedTagId = tagId;
            model.SearchBreed = searchBreed;
            return View(model);
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
            //foreach (var item in tags)
            //{
            //    dogDbContext.DogTags.Add(new DogTag { TagId = item, DogId = dog.Id });
            //}
            //await dogDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        
            //return View(dog);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var dogs = dogDbContext.Dogs
                .Include(x => x.DogTags).ThenInclude(x => x.Tag)
                .Include(x=>x.FCICategory)
                .FirstOrDefault(dogs => dogs.Id == id);
            return View(dogs);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dogs = dogDbContext.Dogs.Find(id);

            ViewBag.fciCategories = new SelectList(dogDbContext.FCICategories, "Id", "Name");

            var selectedTagIds = dogDbContext.DogTags.Where(x => x.DogId == id).Select(x => x.TagId);
            ViewBag.tags = new MultiSelectList(dogDbContext.Tags, "Id", "Name", selectedTagIds);            

            return View(dogs);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var dogs = dogDbContext.Dogs.Find(id);           
            return View(dogs);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var dogs = dogDbContext.Dogs.Find(id);
            dogDbContext.Dogs.Remove(dogs);
            await dogDbContext.SaveChangesAsync();
            TempData["status"] = $"Вы успешно удалили породу {dogs.Breed}!";
            return RedirectToAction("Index");
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


            var dogWithTags = dogDbContext.Dogs.Include(x =>x.DogTags).FirstOrDefault(x => x.Id == dog.Id);
            int a = 0;
            dogDbContext.UpdateManyToMany(
                dogWithTags.DogTags,
                tags.Select(x => new DogTag { DogId = dog.Id, TagId = x }),
                x => x.TagId
                );
            await dogDbContext.SaveChangesAsync();
            TempData["status"] = "Отлично! Вы изменили данные породы!";


            return RedirectToAction("Index");
        }

    }
}
