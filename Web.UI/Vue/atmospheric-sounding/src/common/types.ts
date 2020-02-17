import Vue from 'vue'

export interface IDictionary<T> { [index: string]: T; }

export type VueForm = Vue & { validate: () => boolean } & { reset: () => void };
export type VueInput = Vue & { focus: () => void }
