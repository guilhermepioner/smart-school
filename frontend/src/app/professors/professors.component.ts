import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Professor } from '../models/professor.model';

@Component({
  selector: 'app-professors',
  templateUrl: './professors.component.html'
})
export class ProfessorsComponent implements OnInit {
  public title = 'Professores';
  public selectedProfessor: Professor | null = null;
  public modalRef?: BsModalRef;

  public professors = [
    { id: 1, name: 'Lauro', subject: 'Matemática' },
    { id: 2, name: 'Roberto', subject: 'Física' },
    { id: 3, name: 'Ronaldo', subject: 'Português' },
    { id: 4, name: 'Rodrigo', subject: 'Inglês' },
    { id: 5, name: 'Alexandre', subject: 'Programação' },
  ]
  
  constructor(private modalService: BsModalService) { }

  ngOnInit(): void {
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  selectProfessor(professor: Professor) {
    this.selectedProfessor = professor;
  }

  unselectProfessor() {
    this.selectedProfessor = null;
  }
}
