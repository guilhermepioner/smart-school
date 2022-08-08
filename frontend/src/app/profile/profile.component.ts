import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html'
})
export class ProfileComponent implements OnInit {
  public title = 'Perfil';

  constructor() { }

  ngOnInit(): void {
  }

}
