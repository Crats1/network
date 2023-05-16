using webapi.Models;

namespace webapi.Controllers;

public static class Util
{
    public static IEnumerable<PostDTO> SortPosts(IEnumerable<PostDTO> posts, string? sortOrder)
    {
        return sortOrder switch
        {
            "likes_asc" => posts.OrderBy(post => post.Likes),
            "likes_desc" => posts.OrderByDescending(post => post.Likes),
            "date_asc" => posts.OrderBy(post => post.UpdatedAt ?? post.CreatedAt),
            _ => posts.OrderByDescending(post => post.UpdatedAt ?? post.CreatedAt),
        };
    }
}
