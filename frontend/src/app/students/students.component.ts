import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Student } from '../models/student.model';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html'
})
export class StudentsComponent implements OnInit {
  public title = 'Alunos';
  public selectedStudent: Student | null = null;
  public studentForm!: FormGroup;
  public modalRef?: BsModalRef;

  public students = [
    { id: 1, name: 'Marta', lastname: 'Kent', phone: 332284255 },
    { id: 2, name: 'Paula', lastname: 'Isabela', phone: 3325456455 },
    { id: 3, name: 'Laura', lastname: 'Antonia', phone: 3322648945 },
    { id: 4, name: 'Luiza', lastname: 'Maria', phone: 332245645 },
    { id: 5, name: 'Lucas', lastname: 'Machado', phone: 3322485475 },
    { id: 6, name: 'Pedro', lastname: 'Alvares', phone: 3487956655 },
    { id: 7, name: 'Paulo', lastname: 'José', phone: 33225546785 },
  ];

  constructor(private fb: FormBuilder,
              private modalService: BsModalService) {
    this.createForm(fb);
  }

  ngOnInit(): void {
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  createForm(fb: FormBuilder) {
    this.studentForm = this.fb.group({
      name: ['', Validators.required],
      lastname: ['', Validators.required],
      phone: ['', Validators.required],
    });
  }

  selectStudent(student: Student) {
    this.selectedStudent = student;
    this.studentForm.patchValue(student);
  }

  unselectStudent() {
    this.selectedStudent = null;
  }

  submit() {
    console.log(this.studentForm.value);
  }
}
