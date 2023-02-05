function Remove(ev)
{
    var res = confirm("Are you sure you want to remove this item.");
    if (res != true) { ev.preventDefault(); }
}