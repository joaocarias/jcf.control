import type { Component } from "vue"

export default interface ButtonConfig {
  component: Component
  props?: Record<string, unknown>
}