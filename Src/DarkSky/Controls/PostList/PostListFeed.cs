using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace BlueWP.Controls.PostList
{
  public class PostListFeed : PostListBase
  {
    private bool _followedOnly = false;

    public bool FollowedOnly { get => _followedOnly; set => _followedOnly = value; }

    public string FeedURI
    {
      get { return (string)GetValue(FeedURIProperty); }
      set { SetValue(FeedURIProperty, value); }
    }
    public static readonly DependencyProperty FeedURIProperty = DependencyProperty.Register("FeedURI", typeof(string), typeof(PostListFeed), new PropertyMetadata(string.Empty));

    public async override Task<List<ATProto.IPost>> GetListItems()
    {
      if (string.IsNullOrEmpty(FeedURI))
      {
        var response = await _mainPage.Get<ATProto.Lexicons.App.BSky.Feed.GetTimeline.Response>(new ATProto.Lexicons.App.BSky.Feed.GetTimeline()
        {
          limit = 15//60
        });

        List<ATProto.Lexicons.App.BSky.Feed.Defs.FeedViewPost> feedItems = response?.feed;

        if (feedItems != null && _followedOnly)
        {
            try
            {
                feedItems = feedItems.Where((s) =>
                {
                    if (s?.reply?.parent == null)
                    {
                        return true;
                    }
                    var post = s.reply.parent as ATProto.Lexicons.App.BSky.Feed.Defs.PostView;
                    if (post == null)
                    {
                        return true;
                    }
                    return !string.IsNullOrEmpty(post.author.viewer.following);
                }).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        List<ATProto.IPost> posts = default;

        try
        {
           posts = feedItems.ToList<ATProto.IPost>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return posts;
      }
      else
      {
        ATProto.Lexicons.App.BSky.Feed.GetFeed.Response response = default;

        try
        {
            response = await _mainPage.Get<ATProto.Lexicons.App.BSky.Feed.GetFeed.Response>(
                new ATProto.Lexicons.App.BSky.Feed.GetFeed()
                {
                    limit = 15,//60,
                    feed = FeedURI
                });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return response?.feed.ToList<ATProto.IPost>();
      }
    }
  }
}
