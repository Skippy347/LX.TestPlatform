import { TextField, Box } from "@mui/material";
import styles from "./RegistrationForm.module.scss";

export function RegistrationForm() {
  return (
    <Box className={styles.registration}>
      <TextField
        className={styles.registration_form_input}
        id="filled-basic"
        label="Email"
        variant="filled"
        InputProps={{ disableUnderline: true }}
      />
      <TextField
        className={styles.registration_form_input}
        id="filled-basic"
        label="Add a password"
        variant="filled"
        InputProps={{ disableUnderline: true }}
      />

      <button type="button" className={styles.registration_intro_btn}>
        Sing Up
      </button>
    </Box>
  );
}
