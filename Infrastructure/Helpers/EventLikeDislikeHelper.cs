namespace HowClient.Infrastructure.Helpers;

using Enums;

public class EventLikeDislikeHelper
{
    public static void CountLikeDislike(
        LikeState oldState,
        LikeState newState,
        out int likesCount,
        out int dislikesCount)
    {
        likesCount = 0;
        dislikesCount = 0;
        
        if (oldState == LikeState.None)
        {
            if (newState == LikeState.Like)
            {
                likesCount++;
            }
            else if (newState == LikeState.Dislike)
            {
                dislikesCount++;
            }
        }
        else if (oldState == LikeState.Like)
        {
            if (newState == LikeState.None)
            {
                likesCount--;
            }
            else if (newState == LikeState.Dislike)
            {
                likesCount--;
                dislikesCount++;
            }
        }
        else if (oldState == LikeState.Dislike)
        {
            if (newState == LikeState.None)
            {
                dislikesCount--;
            }
            else if (newState == LikeState.Like)
            {
                dislikesCount--;
                likesCount++;
            }
        }
    }
}