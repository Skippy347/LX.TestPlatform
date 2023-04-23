import { Box, TextField, Typography } from "@mui/material";
import styles from "./IntroSection.module.scss";

export function IntroSection() {
  return (
    <Box className={styles.intro}>
      <Box className="container">
        <Box className={styles.intro_inner}>
          <Typography className={styles.intro_title}>
            Elevate your career with our industry-specific certification tests.
          </Typography>
          <Typography className={styles.intro_subtitle}>
            Ready to test your knowledge? Sign up now to get started.
          </Typography>
          <Box className={styles.intro_form}>
            <TextField
              className={styles.intro_form_input}
              id="filled-basic"
              label="Email address"
              variant="filled"
              InputProps={{ disableUnderline: true }}
            />
            <button className={styles.intro_form_btn} type="button">
              Get Started
            </button>
          </Box>
        </Box>
      </Box>
    </Box>
  );
}
