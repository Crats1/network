using webapi.Models;

namespace webapi.Controllers;

public static class Util
{
    public static IEnumerable<PostDTO> SortPosts(IEnumerable<PostDTO> posts, string? sortOrder)
    {
        switch (sortOrder)
        {
            case "likes_asc":
                return posts.OrderBy(post => post.Likes);
            case "likes_desc":
                return posts.OrderByDescending(post => post.Likes);
            case "date_asc":
                return posts.OrderBy(post => post.UpdatedAt ?? post.CreatedAt);
            default:
                return posts.OrderByDescending(post => post.UpdatedAt ?? post.CreatedAt);
        }
    }
}
