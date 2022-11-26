namespace Razor.Introduction.Tag.Helper.Web.UserCards
{
    public class DefaultUserCardTemplate : UserCardTemplate
    {
        protected override string SetFooter()
        {
            return string.Empty;
        }

        protected override string SetPicture()
        {
            return $"<img class='card-img-top' style='filter: blur(8px);  -webkit-filter: blur(8px);' src='{User.PictureUrl}'>";
        }
    }
}
