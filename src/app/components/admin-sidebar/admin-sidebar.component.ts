import { SidebarService } from './../../services/sidebar.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-sidebar',
  templateUrl: './admin-sidebar.component.html',
  styleUrls: ['./admin-sidebar.component.css']
})
export class AdminSidebarComponent implements OnInit {

  content: string;
  id: string;
  successMsg: boolean = false;

  constructor(
    private router: Router,
    private sidebarService: SidebarService
  ) { }

  ngOnInit() {
    this.sidebarService.getSidebar().subscribe(res => {
      this.content = res['content'];
      this.id = res['id'];
    });
  }

  editSidebar(value){
    this.sidebarService.putSidebar(value).subscribe(res => {
      this.successMsg = true;
      setTimeout(function(){
        this.successMsg = false;
      }.bind(this), 2000);
    });
  }

}
