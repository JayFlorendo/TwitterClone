using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TwitterClone.Models;
using TwitterClone.Data;

namespace TwitterClone.Pages
{

    public class HomeModel : PageModel
    {
        public class tweeter
        {
            public string? textTweet { get; set; }

            public int ? id { get; set; }
            public string? Username { get; set; }

            public DateTime tweetCreated { get; set; }
        }

        
        public Tweets tweet { get; set; }


        private readonly TwitterClone.Data.TwitterCloneContext _context;

        public HomeModel(TwitterClone.Data.TwitterCloneContext context)
        {
            _context = context;
        }
        public IList<Tweets> tweets { get; set; }

        public IList<Followers> follow { get; set; }
        public Followers deleteFollow { get; set; }



        public async Task OnGetAsync(int id, string action)
        {

            if (action == "like")
            {

                tweet = await _context.Tweets.FirstOrDefaultAsync(m => m.Id == id);

                tweet.heart = tweet.heart + 1;

                _context.Attach(tweet).State = EntityState.Modified;
                
                await _context.SaveChangesAsync();
                
            }
            else if (action == "retweet")
            {
                tweet = await _context.Tweets.FirstOrDefaultAsync(m => m.Id == id);

                tweet.retweet = tweet.retweet + 1;


                _context.Tweets.Add(
                         new Tweets
                         {
                             userId = 1,
                             username = "EdwardCatanghal",
                             picture = "images/junpei.jpg",
                             tweet = tweet.username + ": " + tweet.tweet,
                             dateTweeted = DateTime.Now,
                             heart = 0,
                             retweet = 0,
                             reply = 0
                         }
                );

                _context.SaveChanges();

                _context.Attach(tweet).State = EntityState.Modified;

                await _context.SaveChangesAsync();

            } else if (action == "Follow")
            {
                _context.Followers.Add(
                    new Followers
                    {
                        userId = 1,
                        userIdFollow = id
                    }
                );

                _context.SaveChanges();
            } else if (action == "Unfollow")
            {
                deleteFollow = await _context.Followers.FirstOrDefaultAsync(t => t.userId == 1 && t.userIdFollow == id);
                _context.Followers.Remove(deleteFollow);
                await _context.SaveChangesAsync();
            }

            tweets = await _context.Tweets.OrderByDescending(t => t.Id).Take(5).ToListAsync();
            follow = await _context.Followers.Where(m => m.userId == 1).ToListAsync();

        }

        public async Task<IActionResult> OnPost()
        {

            _context.Tweets.Add(
                    new Tweets
                    {
                        userId = 1,
                        username =  "EdwardCatanghal",
                        picture =   "images/junpei.jpg",
                        tweet = Request.Form["tweet"],
                        dateTweeted= DateTime.Now,
                        heart = 0,
                        retweet = 0,
                        reply = 0
                    }
                );

            _context.SaveChanges();

            return RedirectToPage("Home");
        }

    }
}
