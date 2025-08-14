// src/plugins/fontawesome.ts
import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

// Ícones que você quer usar
import { faUser, faLock, faEnvelope, faRightFromBracket, faSpinner, faTriangleExclamation, faDatabase, faSave} from '@fortawesome/free-solid-svg-icons'
import { faGithub } from '@fortawesome/free-brands-svg-icons'

// Adiciona os ícones à biblioteca
library.add(faUser, faLock, faGithub, faEnvelope, faRightFromBracket, faSpinner, faTriangleExclamation, faDatabase, faSave)

export default FontAwesomeIcon
