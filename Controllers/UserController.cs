using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using QuestionPlatform2.Models;
using QuestionPlatform2.Repositories;
using QuestionPlatform2.ViewModels;

[Authorize(Roles = "User")]
public class UserController : Controller
{
    private readonly UserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly INotyfService _notyf;

    public UserController(UserRepository userRepository, IMapper mapper, INotyfService notyf)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _notyf = notyf;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userRepository.GetAllAsync();
        var model = _mapper.Map<List<UserModel>>(users);
        return View(model);
    }

    public IActionResult Add() => View();

    [HttpPost]
    public async Task<IActionResult> Add(UserModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = _mapper.Map<User>(model);
        user.Password = HashPassword(model.Password);
        user.Role = "User";
        user.PhotoUrl = string.IsNullOrEmpty(user.PhotoUrl) ? "no-img.png" : user.PhotoUrl;
        await _userRepository.AddAsync(user);
        _notyf.Success("Kullanıcı eklendi!");
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Update(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        var model = _mapper.Map<UserModel>(user);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UserModel model)
    {
        var user = await _userRepository.GetByIdAsync(model.Id);
        _mapper.Map(model, user);
        await _userRepository.UpdateAsync(user);
        _notyf.Success("Kullanıcı güncellendi!");
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _userRepository.DeleteAsync(id);
        _notyf.Success("Kullanıcı silindi!");
        return RedirectToAction("Index");
    }

    private string HashPassword(string password)
    {
        return password.MD5();
    }


}
