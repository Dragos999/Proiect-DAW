import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import {Router} from '@angular/router';
@Component({
  selector: 'app-user',
  templateUrl:'./user.component.html',
  styleUrl:'./user.component.css'
  
})
export class UserComponent implements OnInit{
  users: any[] = [];
  
  constructor(private userService: UserService, private router:Router) {}

  ngOnInit() {
    this.userService.getUsers().subscribe(data => {
      this.users = data;
    },
    (error)=>{
      console.error('Error',error);
    }
    );
  }



}
