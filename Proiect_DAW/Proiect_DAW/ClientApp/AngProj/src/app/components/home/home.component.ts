import { Component, OnInit } from '@angular/core';
import {  FormBuilder,FormGroup } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  LoginFm!: FormGroup;
  hide=true;
  message:string='If you do not have an account register first!';
  constructor(private fb:FormBuilder,private userService:UserService,private router:Router){ }
 
  ngOnInit(){
    this.LoginFm=this.fb.group({
      UserName:'',
      Password:''
    })

    
  }

  login() {
    const loginDto = {
      username: this.LoginFm.get('UserName')?.value,
      password: this.LoginFm.get('Password')?.value
    };
    this.userService.loginUser(loginDto).subscribe(
      (response) => {
        console.log('Login successful:', response);
        localStorage.setItem('token', response.token);
        localStorage.setItem('currentId',response.id);
        this.router.navigate(['/user']);
      },
      (error) => {
        console.error('Login error:', error);
      }
    );
  }
 
  registerUser() {
    
    const registerDTO = {
      username: this.LoginFm.get('UserName')?.value,
      password: this.LoginFm.get('Password')?.value
    };
    this.userService.addUser(registerDTO).subscribe(
      (response:string) => {
        console.log( response);
        this.message="Now you can Log In!";
      },
      (error) => {
        console.error(error);
      }
    );
  }
  registerAdmin(){
    const registerDTO = {
      username: this.LoginFm.get('UserName')?.value,
      password: this.LoginFm.get('Password')?.value
    };
    this.userService.addAdmin(registerDTO).subscribe(
      (response:string) => {
        console.log( response);
        this.message="Now you can Log In!";
      },
      (error) => {
        console.error(error);
      }
    );
  }
 
}
