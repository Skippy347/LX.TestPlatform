import { Box, Typography } from "@mui/material";
import styles from "./IntroSection.module.scss";
import { RegistrationForm } from "../RegistrationForm";

export function IntroSection() {
  return (
    <Box className={styles.intro}>
      <Box className="container">
        <Box className={styles.intro_inner}>
          <Typography className={styles.intro_title}>
            Create a password to start your membership
          </Typography>
          <Typography className={styles.intro_subtitle}>
            Just a few more steps and you are done!
          </Typography>
          <RegistrationForm />
        </Box>
      </Box>
    </Box>
  );
}
