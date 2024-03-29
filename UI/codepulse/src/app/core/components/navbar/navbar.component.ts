import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../features/auth/services/services.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit{

  constructor(private authService: AuthService){

  }

  ngOnInit(): void {
    this.authService.user()
    .subscribe({
      next:(response)=>{
        console.log(response);
      }
    })
  }

}
