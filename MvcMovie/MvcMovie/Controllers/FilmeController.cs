using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class FilmeController : Controller
    {
        private MovieDBContext movieDB = new MovieDBContext();
        
        // GET: Filme
        //public ActionResult Index()
        //{
        //    var filmes = this.movieDB.Movies
        //                    .Include("Genre")
        //                    .OrderByDescending(a => a.Gross)
        //                    .Take(10).ToList();

        //    return View(filmes);
        //}

        //GET: Filme/searchString
        public ViewResult Index(string searchString, string genreOption)
        {
            var movies = from movie in movieDB.Movies
                         select movie;
            
            var genres = this.movieDB.Genres.Select(g => g.Name).ToList();
            ViewBag.Data = genres;

            if (!String.IsNullOrEmpty(searchString) || !String.IsNullOrEmpty(genreOption))
                movies = movies.Where(s => (s.Title.Contains(searchString) || s.Director.Contains(searchString)) && s.Genre.Name.Equals(genreOption));

            var list = movies.ToList();

            return View(movies.ToList());
        }

        // GET: Filme/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Filme/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filme/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Filme/Edit/5
        public ActionResult Edit(int id)
        {
            Movie filme = this.movieDB.Movies.Find(id);

            if (filme == null) return this.HttpNotFound();

            this.ViewBag.GenreId = new SelectList(
                this.movieDB.Genres,
                "GenreId",
                "Name",
                filme.GenreID
            );

                            
            return View(filme);
        }

        // POST: Filme/Edit/5
        [HttpPost]
        public ActionResult Edit(Movie album)
        {
            if (ModelState.IsValid)
            {
                this.movieDB.Entry(album).State = EntityState.Modified;
                this.movieDB.SaveChanges();

                return this.RedirectToAction("Index");
            }

            this.ViewBag.GenreId = new SelectList(
                this.movieDB.Genres,
                "GenreId",
                "Name",
                album.GenreID
            );

            return this.View(album);
        }

        // GET: Filme/Delete/5
        public ActionResult Delete(int id)
        {
            Movie movie = this.movieDB.Movies.Find(id);

            if (movie == null) return this.HttpNotFound();

            return this.View(movie);
        }

        // POST: Filme/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Movie movie = this.movieDB.Movies.Find(id);
            this.movieDB.Movies.Remove(movie);
            this.movieDB.SaveChanges();

            return this.RedirectToAction("Index");
        }
    }
}
