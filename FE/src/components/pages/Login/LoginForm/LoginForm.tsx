import { Box, TextField } from "@mui/material";
import styles from "./LoginForm.module.scss";

export function LoginForm() {
  return (
    <Box className={styles.login}>
      <TextField
        className={styles.login_form_input}
        id="filled-basic"
        label="Email"
        variant="filled"
        InputProps={{ disableUnderline: true }}
      />
      <TextField
        className={styles.login_form_input}
        id="filled-basic"
        label="Add a password"
        variant="filled"
        InputProps={{ disableUnderline: true }}
      />
      <label htmlFor="isRememberUser">
        <input type="checkbox" id="isRememberUser" className={styles.login_form_checkbox} />
        Remember Me
      </label>

      <button type="button" className={styles.login_intro_btn}>
        Sing In
      </button>
    </Box>
  );
}
