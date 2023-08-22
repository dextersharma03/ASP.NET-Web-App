using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;

public partial class part2_Slideshow : System.Web.UI.Page
{
    private IReadOnlyList<Photo> _photos;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            _photos = _photos ?? Dao.GetAllPhotos();
        }
        catch (Exception)
        {
            _photos = new List<Photo>();
        }
    }

    private Photo GetCurrPhoto() => _photos.FirstOrDefault(p => p.Url.Equals(ImageSlideshow.ImageUrl, StringComparison.InvariantCultureIgnoreCase));

    private void SetCurrPhoto(Photo photo)
    {
        if (photo == null)
            return;

        ImageSlideshow.ImageUrl = photo.Url;
        LblCaption.Text = photo.Description;
    }


    private Photo GetPrevPhoto()
    {
        var currPhoto = GetCurrPhoto();
        if (currPhoto == null)
            return null;

        var prevId = currPhoto.Id == 1 ? 20 : currPhoto.Id - 1;
        return _photos.FirstOrDefault(p => p.Id == prevId);
    }

    private Photo GetNextPhoto()
    {
        var currPhoto = GetCurrPhoto();
        if (currPhoto == null)
            return null;

        var nextId = currPhoto.Id == 20 ? 1 : currPhoto.Id + 1;
        return _photos.FirstOrDefault(p => p.Id == nextId);
    }

    private void SetRandomPhoto()
    {
        var currPhoto = GetCurrPhoto();
        var nextId = currPhoto?.Id;
        if (nextId == null)
            return;

        while (nextId == currPhoto.Id)
        {
            var rnd = new Random();
            nextId = rnd.Next(1,21); // 1 to 20
        }

        var nextPhoto = _photos.FirstOrDefault(p => p.Id == nextId);
        SetCurrPhoto(nextPhoto);
    }

    protected void ImagePrev_Click(object sender, ImageClickEventArgs e)
    {
        if (!IsShuffleOn())
            SetCurrPhoto(GetPrevPhoto());
        else
            SetRandomPhoto();
    }

    protected void ImageNext_Click(object sender, ImageClickEventArgs e)
    {
        NextPhoto();
    }

    private bool IsShuffleOn() => hdnShuffleOn.Value == "true";

    private void SetShuffleOn(bool isOn)
    {
        hdnShuffleOn.Value = isOn ? "true" : "false";
    }

    protected void ImageShuffle_Click(object sender, ImageClickEventArgs e)
    {
        SetShuffleOn(!IsShuffleOn());
        ImageShuffle.BackColor = IsShuffleOn() ? Color.MediumSlateBlue : Color.White;
    }

    protected void ImagePlay_Click(object sender, ImageClickEventArgs e)
    {
        UpdateTimer.Enabled = true;
        ImagePlay.BackColor = Color.ForestGreen;
        ImageStop.BackColor = Color.White;
    }

    protected void ImageStop_Click(object sender, ImageClickEventArgs e)
    {
        UpdateTimer.Enabled = false;
        ImageStop.BackColor = Color.Red;
        ImagePlay.BackColor = Color.White;
    }

    protected void PhotoTick(object sender, EventArgs e)
    {
        ImagePlay.BackColor = Color.ForestGreen;
        ImageStop.BackColor = Color.White;
        NextPhoto();
    }

    private void NextPhoto()
    {
        if (!IsShuffleOn())
            SetCurrPhoto(GetNextPhoto());
        else
            SetRandomPhoto();
    }
}