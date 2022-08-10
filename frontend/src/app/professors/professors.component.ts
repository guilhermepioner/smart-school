import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Professor } from '../models/professor.model';
import { ProfessorService } from '../services/professor.service';

@Component({
  selector: 'app-professors',
  templateUrl: './professors.component.html'
})
export class ProfessorsComponent implements OnInit {
  public title = 'Professores';
  public selectedProfessor: Professor | null = null;
  public professorForm!: FormGroup;
  public modalRef?: BsModalRef;
  public reqType: 'put' | 'post' = 'post';

  public professors: Professor[] = []

  constructor(
    private fb: FormBuilder,
    private modalService: BsModalService,
    private professorService: ProfessorService
  ) {
    this.createForm(fb);
  }

  ngOnInit(): void {
    this.loadProfessors();
  }

  loadProfessors() {
    this.professorService
      .getAll()
      .subscribe({
        next: (professors: Professor[]) => {
          this.professors = professors
        },
        error: (e: any) => {
          console.error(e);
        }
      });
  }

  saveProfessor(professor: Professor) {
    (professor.id == 0) ? this.reqType = 'post' : this.reqType = 'put';

    this.professorService
      [this.reqType](professor)
      .subscribe({
        next: (result: Professor) => {
          console.log(result);
          this.loadProfessors();
        },
        error: (e: any) => {
          console.error(e);
        }
      });
  }

  createProfessor() {
    this.selectedProfessor = new Professor();
    this.professorForm.patchValue(this.selectedProfessor);
  }

  submit() {
    this.saveProfessor(this.professorForm.value);
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  createForm(fb: FormBuilder) {
    this.professorForm = this.fb.group({
      id: [''],
      name: ['', Validators.required],
      // subject: ['', Validators.required],
    });
  }

  selectProfessor(professor: Professor) {
    this.selectedProfessor = professor;
    this.professorForm.patchValue(professor);
  }

  unselectProfessor() {
    this.selectedProfessor = null;
  }
}
