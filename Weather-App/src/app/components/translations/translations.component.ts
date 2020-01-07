import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { TranslationService } from 'src/app/services/translation.service';

@Component({
  selector: 'app-translations',
  templateUrl: './translations.component.html',
  styleUrls: ['./translations.component.scss']
})
export class TranslationsComponent implements OnInit {
  languages = ['English', 'Ukrainian'];

  translationsForm: FormGroup;

  constructor(private router: Router, private translation: TranslationService) { }

  ngOnInit() {
    this.translationsForm = new FormGroup({
      'page_title': new FormControl(null),
      'form_title': new FormControl(null),
      'back_btn': new FormControl(null),
      'search_btn': new FormControl(null),
      'general': new FormControl(null),
      'pressure': new FormControl(null),
      'humidity': new FormControl(null),
      'clouds': new FormControl(null),
      'loading': new FormControl(null),
      'okay': new FormControl(null),
      'clear': new FormControl(null),
      'error': new FormControl(null),
      'welcome': new FormControl(null),
      'start': new FormControl(null),
      'change_translation_btn': new FormControl(null),
      'no_city': new FormControl(null),
      'invalid_data': new FormControl(null)
    });
  }

  onBack() {
    this.router.navigate(['']);
  }

  onSaveTranslations() {
    this.translation.makeSetTranslationRequest();
  }
}
